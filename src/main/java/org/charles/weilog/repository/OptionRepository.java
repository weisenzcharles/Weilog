package org.charles.weilog.repository;

import org.charles.weilog.domain.Option;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 选项数据仓库。
 *
 * @author Charles
 */
public interface OptionRepository extends JpaRepository<Option, Long>, JpaSpecificationExecutor<Option> {
}
